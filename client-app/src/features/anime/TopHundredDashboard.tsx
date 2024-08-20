import { Box, Grid, Typography } from "@mui/material";
import { Anime } from "../../app/models/entities/anime";
import AnimeShortDetails from "./AnimeShortDetails";
import { useTranslation } from "react-i18next";

interface Props {
  animeList: Anime[];
}

export default function TopHundredDashboard({ animeList }: Props) {
  const { t } = useTranslation();

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
        <Typography style={{ marginTop: "20px", marginBottom:"50px" }} variant="h4" component="div">
          {t("Top-100 Anime")}
        </Typography>
        <Grid
          container
          spacing={{ xs: 2, md: 3 }}
          columns={{ xs: 5, sm: 5, md: 5 }} // Change this to 5
          sx={{ justifyContent: "left" }}
        >
          {animeList.map((anime, index) => (
            <Grid
              item
              xs={"auto"}
              sm={"auto"}
              md={"auto"}
              lg={"auto"} // Change lg to 2 to fit 6 elements per row (This is closest to 5)
              key={anime.id}
            >
              <Box
                sx={{
                  display: "flex",
                  alignItems: "top",
                  flexDirection: "row", // Align items in a row
                  gap: 2, // Add space between the index and the AnimeShortDetails
                }}
              >
                <Typography variant="h6">{`${index + 1}.`}</Typography>
                <AnimeShortDetails anime={anime} />
              </Box>
            </Grid>
          ))}
        </Grid>
      </Box>
    </Box>
  );
}
