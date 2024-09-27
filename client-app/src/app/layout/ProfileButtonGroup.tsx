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
    <Box>
      {user && (
        <>
          <img src={user.avatar.url} alt="User Image" />
          <Typography>{user.userNickname}</Typography>
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
