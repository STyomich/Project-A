import { createContext, useContext } from "react";
import AnimeStore from "./animeStore";

interface Store {
    animeStore: AnimeStore
}
export const store: Store = {
    animeStore: new AnimeStore()
}
export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}