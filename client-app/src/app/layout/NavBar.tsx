import {
  AppBar,
  Box,
  Button,
  IconButton,
  Toolbar,
  Typography,
} from "@mui/material";
import { useTranslation } from "react-i18next";
import LanguageSwitcher from "./LanguageSwitcher";
import { NavLink } from "react-router-dom";
import Logo from "./Logo";
import ProfileButtonGroup from "./ProfileButtonGroup";

export default function NavBar() {
  const { t } = useTranslation();

  return (
    <Box sx={{ marginBottom: "50px" }}>
      <AppBar position="absolute" style={{ backgroundColor: "#0e1420" }}>
        <Toolbar>
          <Box sx={{ display: "flex", alignItems: "center", flexGrow: 1 }}>
            <IconButton
              size="large"
              edge="start"
              color="inherit"
              aria-label="logo"
            >
              <Logo />

              <Typography
                variant="h5"
                component="div"
                style={{ fontWeight: "bold", justifyContent: "center" }}
              >
                {t("Project A")}
              </Typography>
            </IconButton>
            <Button
              variant="text"
              style={{ color: "white", fontWeight: "bold", marginLeft: "20px" }}
            >
              {t("List")}
            </Button>
            <Button
              variant="text"
              style={{ color: "white", fontWeight: "bold", marginLeft: "20px" }}
            >
              {t("Random anime")}
            </Button>
            <Button
              component={NavLink}
              to="/top-hundred-animes" // or as={NavLink}, but in this case use @ts-ignore
              variant="text"
              style={{ color: "white", fontWeight: "bold", marginLeft: "20px" }}
            >
              {t("Top-100")}
            </Button>
          </Box>
          <Box sx={{ display: "flex", alignItems: "center" }}>
            <LanguageSwitcher />
            <ProfileButtonGroup />
          </Box>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
