import { createContext, useContext } from "react";
import AnimeStore from "./animeStore";
import UserStore from "./userStore";

interface Store {
    animeStore: AnimeStore,
    userStore: UserStore
}
export const store: Store = {
    animeStore: new AnimeStore(),
    userStore: new UserStore()
}
export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}