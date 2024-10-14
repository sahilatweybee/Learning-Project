import { configureStore, Store } from "@reduxjs/toolkit";
import chatReducer from "../slice/chatSlice";

const store = configureStore({
  reducer: {
    chat: chatReducer,
  },
});

export type ChatDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;

export default store;
