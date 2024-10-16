import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import React, { useState } from "react";
import { useChatConnection, useChatSelector, useSendMessage } from "../hooks";

const MessageInput: React.FC = () => {
  const [message, setMessage] = useState<string>("");
  const currentUser = useChatSelector((state) => state.chat.userName);
  const connection = useChatConnection();
  const sendMessage = useSendMessage();
  const handleSendMessage = () => {
    if (message.trim()) {
      sendMessage(
        { sender: currentUser, isMine: true, text: message },
        connection
      );
      // onSendMessage(message);
      setMessage("");
    }
  };

  return (
    <div className="flex items-center p-4 bg-white">
      <Input
        type="text"
        placeholder="Type a message..."
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        onKeyDown={(e) => e.key === "Enter" && handleSendMessage()}
        className="flex-grow mr-2"
      />
      <Button onClick={handleSendMessage}>Send</Button>
    </div>
  );
};

export default MessageInput;
