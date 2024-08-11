import { useStore } from "../stores/store";
import NavBar from "./NavBar";

function App() {
  const { animeStore } = useStore();


  return (
    <>
      <NavBar/>
      <h2>{animeStore.title}</h2>
    </>
  );
}

export default App;
