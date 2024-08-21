import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Outlet } from "react-router-dom";

function App() {
  

  return (
    <>
      <NavBar/>
      <Outlet />
    </>
  );
}

export default observer(App);
