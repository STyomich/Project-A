import { makeAutoObservable, runInAction } from "mobx";
import { Anime } from "../models/entities/anime";
import agent from "../api/agent";

export default class AnimeStore {
  animes: Anime[] = [];
  selectedAnime: Anime | undefined = undefined;
  loading = false;

  constructor() {
    makeAutoObservable(this);
  }

  loadAnimes = async () => {
    this.loading = true;
    try {
      this.animes = [];
      const animes = await agent.Animes.list();
      animes.forEach((anime) => {
        runInAction(() => {
          this.animes.push(anime);
        });
        console.log(anime);
      });
      this.loading = false;
    } catch (error) {
      console.log(error);
      this.loading = false;
    }
  };

  loadAnime = async (id: string) => {
    this.loading = true;
    try {
      const anime = await agent.Animes.details(id);
      runInAction(() => {
        this.selectedAnime = anime;
      });
      this.loading = false;
    } catch (error) {
      console.log(error);
      this.loading = false;
    }
  };
}
