// src/components/ChatWindow.tsx
import React from "react";
import MessageBubble from "./MessageBubble";
import MessageInput from "./MessageInput";
import { ChatMessage } from "@/types";

interface ChatWindowProps {
  messages: ChatMessage[];
  onSendMessage: (message: string) => void;
}

const ChatWindow: React.FC<ChatWindowProps> = ({ messages, onSendMessage }) => {
  return (
    <div className='flex flex-col h-full'>
      <div className='flex-grow overflow-y-auto p-4 bg-gray-50'>
        {messages.map((message, index) => (
          <MessageBubble key={index} message={message} />
        ))}
      </div>
      <MessageInput onSendMessage={onSendMessage} />
    </div>
  );
};

export default ChatWindow;
