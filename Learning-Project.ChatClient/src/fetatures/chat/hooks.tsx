import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { RootState, ChatDispatch } from "./store/messageStore";
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from "@microsoft/signalr";
import { ChatMessage } from "@/types";
import { setNewMessage } from "./slice/chatSlice";

export const useChatDispatch = () => useDispatch<ChatDispatch>();
export const useChatSelector: TypedUseSelectorHook<RootState> = useSelector;

export const useChatConnection: () => HubConnection = () => {
  const connection = new HubConnectionBuilder()
    .withUrl("wss://localhost:44324/chat", {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets,
      /*accessTokenFactory: () => "access_token",*/
    })
    .configureLogging(LogLevel.None)
    .build();
  return connection;
};

export const useSendMessage = () => {
  const dispatch = useChatDispatch();
  return async (message: ChatMessage, connection: HubConnection) => {
    try {
      if (connection.state !== HubConnectionState.Connected) {
        console.log("Connecting to signalR");
        await connection.start();
        connection.invoke("NotifyAsync", message.sender, message.text);
        dispatch(setNewMessage(message));
      }
      console.log("SignalR Connected.");
    } catch (err) {
      console.log(err);
      // setTimeout(start, 2000);
    }
  };
};

// connection.onclose(async () => {
//   await useStartConnection();
// });
