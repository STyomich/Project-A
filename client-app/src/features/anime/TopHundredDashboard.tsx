import { Box, CircularProgress, Grid, Typography } from "@mui/material";
import AnimeShortDetails from "./AnimeShortDetails";
import { useTranslation } from "react-i18next";
import { useEffect } from "react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

function TopHundredDashboard() {
  const { t } = useTranslation();
  const { animeStore } = useStore();
  const {animes, loadAnimes} = animeStore;

  useEffect(() => {
    loadAnimes();
  }, [loadAnimes]);

  console.log(animes);

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "top",
        minHeight: "100vh",
        marginTop: "100px",
      }}
    >
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "left",
          backgroundColor: "white",
          padding: 2,
          borderRadius: 1,
          width: "100%",
          maxWidth: 1500,
          boxShadow: 3,
        }}
      >
        <Typography
          style={{ marginTop: "20px", marginBottom: "50px" }}
          variant="h4"
          component="div"
        >
          {t("Top-100 Anime")}
        </Typography>
        {animes.length > 0 ? (
          <Grid
            container
            spacing={{ xs: 2, md: 3 }}
            columns={{ xs: 5, sm: 5, md: 5 }} 
            sx={{ justifyContent: "left" }}
          >
            {animes.map((anime, index) => (
              <Grid
                item
                xs={"auto"}
                sm={"auto"}
                md={"auto"}
                lg={"auto"} 
                key={anime.id}
              >
                <Box
                  sx={{
                    display: "flex",
                    alignItems: "top",
                    flexDirection: "row", 
                    gap: 2, 
                  }}
                >
                  <Typography variant="h6">{`${index + 1}.`}</Typography>
                  <AnimeShortDetails anime={anime} />
                </Box>
              </Grid>
            ))}
          </Grid>
        ) : (
          <CircularProgress color="inherit"/>
        )}
      </Box>
    </Box>
  );
}  

export default observer(TopHundredDashboard);