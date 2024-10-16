// src/components/MessageBubble.tsx
import { ChatMessage } from "@/types";
import React from "react";
import { Avatar } from "@/components/ui/avatar";

interface MessageBubbleProps {
  message: ChatMessage;
}

const MessageBubble: React.FC<MessageBubbleProps> = ({ message }) => {
  const { sender, text, isMine } = message;

  return (
    <div className={`flex ${isMine ? "justify-end" : "justify-start"} mb-4`}>
      {!isMine && (
        <Avatar
          key={sender}
          className="mr-2"
        />
      )}
      <div
        className={`p-3 rounded-lg max-w-xs ${
          isMine ? "bg-blue-600 text-white" : "bg-gray-200 text-black"
        }`}
      >
        <span className="text-sm font-semibold">{sender}</span>
        <p>{text}</p>
      </div>
    </div>
  );
};

export default MessageBubble;
