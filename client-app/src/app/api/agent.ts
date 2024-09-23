import axios, { AxiosResponse } from "axios";
import { Anime } from "../models/entities/anime";
import { UserLoginValues, UserRegisterValues } from "../models/identity/user";

axios.defaults.baseURL = "http://localhost:5000/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: NonNullable<unknown>) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: NonNullable<unknown>) =>
    axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Animes = {
    list: () => requests.get<Anime[]>('/anime'),
    create: (anime: Anime) => requests.post<void>("/anime", anime),
    details: (id: string) => requests.get<Anime>(`/anime/${id}`),
    update: (anime: Anime) => requests.put<void>(`/anime/${anime.id}`, anime),
    delete: (id: string) => requests.del<void>(`/anime/${id}`)
}

const Account ={
  login: (userLoginValues: UserLoginValues) => requests.post<UserLoginValues>("/user/login", userLoginValues),
  register: (userRegisterValues: UserRegisterValues) => requests.post<UserRegisterValues>("/user/register", userRegisterValues)
}

const agent = {
    Animes,
    Account
}

export default agent;
