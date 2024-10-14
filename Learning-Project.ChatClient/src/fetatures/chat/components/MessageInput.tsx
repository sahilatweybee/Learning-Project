import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import React, { useState } from "react";
import { useChatDispatch, useChatSelector } from "../hooks";
import { sendMessages } from "../redux/slice/chatSlice";

const MessageInput: React.FC = () => {
  const [message, setMessage] = useState<string>("");

  const dispatch = useChatDispatch();
  const currentUser = useChatSelector((state) => state.chat.userName);
  const handleSendMessage = () => {
    if (message.trim()) {
      dispatch(
        sendMessages({ sender: currentUser, isMine: true, text: message })
      );
      // onSendMessage(message);
      setMessage("");
    }
  };

  return (
    <div className='flex items-center p-4 bg-white'>
      <Input
        type='text'
        placeholder='Type a message...'
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        onKeyDown={(e) => e.key === "Enter" && handleSendMessage()}
        className='flex-grow mr-2'
      />
      <Button onClick={handleSendMessage}>Send</Button>
    </div>
  );
};

export default MessageInput;
