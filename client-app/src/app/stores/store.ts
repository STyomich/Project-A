import { createContext, useContext } from "react";
import AnimeStore from "./animeStore";
import UserStore from "./userStore";
import CommonStore from "./commonStore";

interface Store {
    animeStore: AnimeStore,
    userStore: UserStore,
    commonStore: CommonStore
}
export const store: Store = {
    animeStore: new AnimeStore(),
    userStore: new UserStore(),
    commonStore: new CommonStore()
}
export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}