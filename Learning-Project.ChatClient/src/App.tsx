import React from "react";
import { ChatWindow } from "@/fetatures";

const App: React.FC = () => {
  return (
    <div className='h-screen flex items-center justify-center bg-gray-100'>
      <div className='w-full max-w-lg bg-white shadow-md rounded-lg'>
        <ChatWindow />
      </div>
    </div>
  );
};

export default App;

