// src/components/ChatWindow.tsx
import React from "react";
import MessageBubble from "./MessageBubble";
import MessageInput from "./MessageInput";
import { useChatConnection, useChatDispatch, useChatSelector } from "../hooks";
import { setNewMessage } from "../slice/chatSlice";
import { ChatMessage } from "@/types";

const ChatWindow: React.FC = () => {
  const messages = useChatSelector((state) => state.chat.messages);

  const dispatch = useChatDispatch();

  const connection = useChatConnection();

  connection.on(
    "GetNotification",
    (sender: string, text: string, time: Date) => {
      console.log(`[${time}] `, sender, "\t", text);

      const message: ChatMessage = { sender: "", text: "", isMine: false };
      message.sender = sender;
      message.text = text;
      dispatch(setNewMessage(message));
    }
  );

  return (
    <div className="flex flex-col h-full">
      <div className="flex-grow overflow-y-auto p-4 bg-gray-50">
        {messages.map((message, index) => (
          <MessageBubble
            key={index}
            message={message}
          />
        ))}
      </div>
      <MessageInput />
    </div>
  );
};

export default ChatWindow;
