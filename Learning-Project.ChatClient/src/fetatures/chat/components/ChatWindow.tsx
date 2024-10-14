// src/components/ChatWindow.tsx
import React from "react";
import MessageBubble from "./MessageBubble";
import MessageInput from "./MessageInput";
import { useChatSelector } from "../hooks";

const ChatWindow: React.FC = () => {
  const messages = useChatSelector((state) => state.chat.messages);

  return (
    <div className='flex flex-col h-full'>
      <div className='flex-grow overflow-y-auto p-4 bg-gray-50'>
        {messages.map((message, index) => (
          <MessageBubble key={index} message={message} />
        ))}
      </div>
      <MessageInput />
    </div>
  );
};

export default ChatWindow;
