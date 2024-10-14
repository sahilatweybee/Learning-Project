import { ChatMessage } from "@/types";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from "@microsoft/signalr";

interface ChatState {
  messages: ChatMessage[];
  userName: string;
}

const initialState: ChatState = {
  userName: "Anoynemous",
  messages: [
    { sender: "Alice", text: "Hello!", isMine: false },
    { sender: "Anoynemous", text: "Hey Alice!", isMine: true },
  ],
};

const chatSlice = createSlice({
  name: "chat",
  initialState: initialState,
  reducers: {
    sendMessages(state, action: PayloadAction<ChatMessage>) {
      start().then(() => {
        send(action.payload);
      });
      state.messages = [...state.messages, action.payload]; //state.messages[0]];
    },
  },
});

export const connection: HubConnection = new HubConnectionBuilder()
  .withUrl("https://localhost:44324/chat", {
    skipNegotiation: true,
    transport: HttpTransportType.WebSockets,
    /*accessTokenFactory: () => "access_token",*/
  })
  .configureLogging(LogLevel.None)
  .build();

export const start = async () => {
  try {
    if (connection.state !== HubConnectionState.Connected) {
      console.log("Connecting to signalR");
      await connection.start();
    }
    console.log("SignalR Connected.");
  } catch (err) {
    console.log(err);
    setTimeout(start, 2000);
  }
};

connection.onclose(async () => {
  await start();
});

export const send = (message: ChatMessage) =>
  connection.invoke("NotifyAsync", { ...message });

export const { sendMessages } = chatSlice.actions;
export default chatSlice.reducer;
