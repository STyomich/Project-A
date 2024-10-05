import axios, { AxiosResponse } from "axios";
import { Anime } from "../models/entities/anime";
import {
  User,
  UserLoginValues,
  UserRegisterValues,
} from "../models/identity/user";
import { store } from "../stores/store";
import { AnimePin, AnimePinCreateValues } from "../models/entities/animePin";

axios.defaults.baseURL = "http://localhost:5000/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use((config) => {
  const token = store.commonStore.token;
  if (token && config.headers) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: NonNullable<unknown>) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: NonNullable<unknown>) =>
    axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Animes = {
  list: () => requests.get<Anime[]>("/anime"),
  create: (anime: Anime) => requests.post<void>("/anime", anime),
  details: (id: string) => requests.get<Anime>(`/anime/${id}`),
  update: (anime: Anime) => requests.put<void>(`/anime/${anime.id}`, anime),
  delete: (id: string) => requests.del<void>(`/anime/${id}`),
  pinAnimeToUser: (pin: AnimePinCreateValues) => requests.post<void>("/animepin/pin-anime-to-user", pin),
  listAnimePinedByUser: (nickname: string) => requests.get<AnimePin[]>(`/animepin/users-anime/${nickname}`)
};

const Account = {
  current: () => requests.get<User>("/user"),
  login: (userLoginValues: UserLoginValues) =>
    requests.post<User>("/user/login", userLoginValues),
  register: (userRegisterValues: UserRegisterValues) =>
    requests.post<User>("/user/register", userRegisterValues),
};

const agent = {
  Animes,
  Account,
};

export default agent;
