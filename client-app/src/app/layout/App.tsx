import { useEffect } from "react";
import { useStore } from "../stores/store";
import NavBar from "./NavBar";
import { Outlet } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { Typography } from "@mui/material";

function App() {
  const { commonStore, userStore } = useStore();

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore]);

  if (!commonStore.appLoaded)
    return <Typography>Loading</Typography>;

  return (
    <>
      <NavBar />
      <Outlet />
    </>
  );
}

export default observer(App);
