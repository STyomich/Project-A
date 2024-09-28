import { makeAutoObservable, runInAction } from "mobx";
import { User, UserLoginValues } from "../models/identity/user";
import agent from "../api/agent";
import { store } from "./store";

export default class UserStore {
  user: User | null = null;

  constructor() {
    makeAutoObservable(this);
  }

  get isLoggedIn() {
    return !!this.user;
  }

  login = async (creds: UserLoginValues) => {
    const user = await agent.Account.login(creds);
    store.commonStore.setToken(user.token);
    runInAction(() => (this.user = user));
    console.log(user);
  };

  logout = () => {
    store.commonStore.setToken(null);
    //localStorage.removeItem('jwt')
    this.user = null;
  };
  getUser = async () => {
    try {
      const user = await agent.Account.current();
      runInAction(() => (this.user = user));
    } catch (error) {
      console.log(error);
    }
  };
}
