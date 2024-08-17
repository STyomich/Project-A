import { useEffect } from "react";
import { useStore } from "../stores/store";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Anime } from "../models/entities/anime";
import Dashboard from "../../features/anime/Dashboard";

function App() {
  const { animeStore } = useStore();
 

  useEffect(() => {
    animeStore.loadAnimes();
  }, [animeStore])

  return (
    <>
      <NavBar/>
      {animeStore.animes.map((anime:Anime) => (
        console.log(anime.description)
      ))}
      <Dashboard animeList={animeStore.animes as Anime[]} />
    </>
  );
}

export default observer(App);
