import { makeAutoObservable, runInAction } from "mobx";
import { Anime } from "../models/entities/anime";
import agent from "../api/agent";
import { AnimePin, AnimePinCreateValues } from "../models/entities/animePin";

export default class AnimeStore {
  animes: Anime[] = [];
  usersAnimes: AnimePin [] = [];
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

  pinAnimeToUser = async (pin: AnimePinCreateValues) => {
    this.loading = true;
    try {
      await agent.Animes.pinAnimeToUser(pin);
      this.loading = false;
    } catch (error) {
      console.log(error);
      this.loading = false;
    }
  };
  loadAnimeFromUserList = async(userNickname: string) => {
    this.loading = true;
    try {
      this.usersAnimes = [];
      const usersAnimes = await agent.Animes.listAnimePinedByUser(userNickname);
      usersAnimes.forEach((anime) => {
        runInAction(() => {
          this.usersAnimes.push(anime);
        });
      });
      this.loading = false;
    } catch (error) {
      console.log(error)
      this.loading = false
    }
  }
}
