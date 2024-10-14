import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { RootState, ChatDispatch } from "./redux/store/messageStore";

export const useChatDispatch = () => useDispatch<ChatDispatch>();
export const useChatSelector: TypedUseSelectorHook<RootState> = useSelector;
