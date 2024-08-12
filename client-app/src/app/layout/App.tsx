import { useEffect } from "react";
import { useStore } from "../stores/store";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Anime } from "../models/entities/anime";

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
    </>
  );
}

export default observer(App);
