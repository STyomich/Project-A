import { makeAutoObservable } from "mobx";
import { User, UserLoginValues } from "../models/identity/user";
import agent from "../api/agent";

export default class UserStore {
    user: User | null = null

    constructor(){
        makeAutoObservable(this)
    }

    get isLoggedIn(){
        return !!this.user
    }

    login = async (creds: UserLoginValues) =>{
        const user = await agent.Account.login(creds);
        console.log(user)
    }
}