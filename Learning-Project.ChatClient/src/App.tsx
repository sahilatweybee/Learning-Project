// src/App.tsx
import React, { useState } from "react";
import { ChatWindow } from "@/fetatures";
import { ChatMessage } from "./types";

const App: React.FC = () => {
  const [messages, setMessages] = useState<ChatMessage[]>([
    { sender: "Alice", text: "Hello!", isMine: false },
    { sender: "Bob", text: "Hey Alice!", isMine: true },
  ]);

  const handleSendMessage = (messageText: string) => {
    setMessages([
      ...messages,
      { sender: "Bob", text: messageText, isMine: true },
    ]);
  };

  return (
    <div className='h-screen flex items-center justify-center bg-gray-100'>
      <div className='w-full max-w-lg bg-white shadow-md rounded-lg'>
        <ChatWindow messages={messages} onSendMessage={handleSendMessage} />
      </div>
    </div>
  );
};

export default App;

