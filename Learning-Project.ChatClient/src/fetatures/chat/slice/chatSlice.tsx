import { ChatMessage } from "@/types";
import { createSlice, PayloadAction } from "@reduxjs/toolkit";

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
    setNewMessage: (state, action: PayloadAction<ChatMessage>) => {
      state.messages = [...state.messages, action.payload];
    },
  },
});

export const { setNewMessage } = chatSlice.actions;
export default chatSlice.reducer;
