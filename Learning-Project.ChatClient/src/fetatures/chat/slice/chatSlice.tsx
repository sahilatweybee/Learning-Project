import { ChatMessage } from "@/types";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { send, start } from "../../chatApi";
interface ChatState {
  messages: ChatMessage[];
  userName: string;
}

const initialState: ChatState = {
  userName: "Anoynemous",
  messages: [
    // { sender: "Alice", text: "Hello!", isMine: false },
    // { sender: "Anoynemous", text: "Hey Alice!", isMine: true },
  ],
};

const chatSlice = createSlice({
  name: "chat",
  initialState: initialState,
  reducers: {
    sendMessages(state, action: PayloadAction<ChatMessage>) {
      start()
        .then(() => {
          send(action.payload);
        })
        .catch((e) => console.log(e));
      state.messages = [...state.messages, action.payload]; //state.messages[0]];
    },
    setMessage(state, action: PayloadAction<ChatMessage>) {
      state.messages = [...state.messages, action.payload];
    },
  },
});

export const { sendMessages, setMessage } = chatSlice.actions;
export default chatSlice.reducer;
