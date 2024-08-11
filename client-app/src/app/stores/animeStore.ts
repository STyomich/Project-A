import { makeObservable, observable } from "mobx";

export default class AnimeStore {
    title= 'Hello from MobX!';

    constructor() {
        makeObservable(this, {
            title: observable
        })
    }
}