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

export default function NavBar() {
  const { t } = useTranslation();

  return (
    <AppBar position="absolute" style={{ backgroundColor: "#0e1420" }}>
      <Toolbar>
        <Box sx={{ display: "flex", alignItems: "center", flexGrow: 1 }}>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="logo"
            
          >
            <img src="src/assets/logo.png" width="35" height="35" alt="Logo"  />

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
        </Box>
        <Box sx={{ display: "flex", alignItems: "center" }}>
          <LanguageSwitcher />
        </Box>
      </Toolbar>
    </AppBar>
  );
}
