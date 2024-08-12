import { makeAutoObservable, runInAction } from "mobx";
import { Anime } from "../models/entities/anime";
import agent from "../api/agent";

export default class AnimeStore {
    animes: Anime[] = [];
    //selectedAnime: Anime | null = null;
    loading = false;

    constructor() {
        makeAutoObservable(this)
    }

    loadAnimes = async () => {
        this.loading = true;
        try {
            const animes = await agent.Animes.list();
            animes.forEach(anime => {
                anime.startDate = anime.startDate.split('T')[0];
                anime.endDate = anime.endDate.split('T')[0];
                runInAction(() => {
                    this.animes.push(anime);
                })
                console.log(anime);
            })
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.loading = false;
        }
    }
}