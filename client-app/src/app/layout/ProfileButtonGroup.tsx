import { useTranslation } from "react-i18next";
import { useStore } from "../stores/store";
import { Box, Button, Typography } from "@mui/material";
import { observer } from "mobx-react-lite";
import { NavLink } from "react-router-dom";

export default observer(function ProfileButtonGroup() {
  const { t } = useTranslation();
  const { userStore } = useStore();
  const { user } = userStore;

  return (
    <Box sx={{ display: "flex", alignItems: "center", flexGrow: 1 }}>
      {user && (
        <>
          <Button
            component={NavLink}
            to={`/profile/${user.userNickname}`}
            sx={{
              display: "flex",
              alignItems: "center",
              textTransform: "none",
            }}
          >
            <img
              src={user.avatar.url}
              style={{ marginRight: "10px" }}
              width="35"
              height="35"
              alt="User Image"
            />
            <Typography sx={{color:"white"}}>{user.userNickname}</Typography>
          </Button>
        </>
      )}
      {!user && (
        <>
          <Button
            component={NavLink}
            sx={{
              backgroundColor: "white",
              color: "black",
              "&:hover": {
                backgroundColor: "#0e1420", // change background to black on hover
                color: "white", // change text color to white on hover
              },
            }}
            to="/login"
          >
            {t("Login")}
          </Button>
          <Button sx={{ color: "white" }}>{t("Register")}</Button>
        </>
      )}
    </Box>
  );
});
