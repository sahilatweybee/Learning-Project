import { ChatMessage } from "@/types";
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from "@microsoft/signalr";

export const connection: HubConnection = new HubConnectionBuilder()
  .withUrl("wss://localhost:44324/chat", {
    skipNegotiation: true,
    transport: HttpTransportType.WebSockets,
    /*accessTokenFactory: () => "access_token",*/
  })
  .configureLogging(LogLevel.None)
  .build();

export const start = async () => {
  try {
    if (connection.state !== HubConnectionState.Connected) {
      console.log("Connecting to signalR");
      await connection.start();
    }
    console.log("SignalR Connected.");
  } catch (err) {
    console.log(err);
    // setTimeout(start, 2000);
  }
};

connection.onclose(async () => {
  await start();
});

export const send = (message: ChatMessage) =>
  connection.invoke("NotifyAsync", message.sender, message.text);
