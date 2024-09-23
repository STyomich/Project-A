import { Image } from "../entities/image";
import { UserSettings } from "./userSettings";

export interface User {
  avatar: Image;
  userNickname: string;
  userName: string;
  userSurname: string;
  email: string;
  bio: string;
  country: string;
  token: string;
  userSettings: UserSettings;
}

export interface UserLoginValues {
  email: string;
  password: string;
}
export interface UserRegisterValues {
  nickname: string;
  email: string;
  password: string;
}
