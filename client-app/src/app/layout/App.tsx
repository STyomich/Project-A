import { useEffect } from "react";
import { useStore } from "../stores/store";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Anime } from "../models/entities/anime";
import TopHundredDashboard from "../../features/anime/TopHundredDashboard";

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
      <TopHundredDashboard animeList={animeStore.animes as Anime[]} />
    </>
  );
}

export default observer(App);
