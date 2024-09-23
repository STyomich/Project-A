import { Box, Typography } from "@mui/material";
import { Anime } from "../../app/models/entities/anime";
import { useTranslation } from "react-i18next";
import CircleIcon from '@mui/icons-material/Circle';
import { green } from "@mui/material/colors";

interface Props {
  anime: Anime | undefined;
}

function AnimeInfo({ anime }: Props) {
  const { t } = useTranslation();

  if (!anime) {
    return <Typography>{t("No anime data available.")}</Typography>;
  }
  // Parse the UTC JSON date string to a Date object
  const startDate = new Date(anime.startDate);
  const endDate = anime.endDate ? new Date(anime.endDate) : null;

  const getSeason = (date: Date): string => {
    const month = date.getUTCMonth() + 1; // getUTCMonth() returns 0-11

    if (month >= 3 && month <= 5) {
      return `Spring`;
    } else if (month >= 6 && month <= 8) {
      return `Summer`;
    } else if (month >= 9 && month <= 11) {
      return `Autumn`;
    } else {
      return `Winter`;
    }
  };

  return (
    <Box
      sx={{
        backgroundColor: "white",
        maxWidth: 500,
      }}
    >
      {/* Type */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>{t("Type")}</Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          <Typography>{t(anime.type)}</Typography>
        </Box>
      </Box>

      {/* Episodes */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>
            {t("Episodes")}
          </Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          <Typography>
            {anime.episodes.length} / {anime.expectedEpisodes}
          </Typography>
        </Box>
      </Box>

      {/* State */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>{t("State")}</Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          {anime.animeState === "Released" && 
            <CircleIcon sx={{fontSize: 18}} htmlColor="#23de05"/>
          }
          
          <Typography>{t(anime.animeState)}</Typography>
        </Box>
      </Box>

      {/* Genres */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>{t("Genres")}</Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          {anime.genres.map((genre, index) => (
            <Typography
              key={genre.id}
              sx={{ marginRight: index < anime.genres.length - 1 ? 1 : 0 }}
            >
              {t(`${genre.title}`)}
              {index < anime.genres.length - 1 && ","}
            </Typography>
          ))}
        </Box>
      </Box>

      {/* Original Source */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>
            {t("Original source")}
          </Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          <Typography>{t(anime.originalSource)}</Typography>
        </Box>
      </Box>

      {/* Season */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>{t("Season")}</Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          <Typography>
            {t(`${t(getSeason(startDate))} ${startDate.getUTCFullYear()}`)}
            {endDate &&
              ` (${t("finished at")} ${t(
                `${getSeason(endDate)}`
              )} ${endDate.getUTCFullYear()})`}
          </Typography>
        </Box>
      </Box>
      {/* Studio */}
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center", // align items vertically
          justifyContent: "space-between", // align items horizontally
          backgroundColor: "white",
          maxWidth: 1500,
        }}
        style={{ marginBottom:"5px" }}
      >
        <Box sx={{ display: "flex" }}>
          <Typography style={{ fontWeight: "bold" }}>{t("Studio")}</Typography>
        </Box>
        <Box sx={{ display: "flex" }}>
          <Typography>{t(anime.studio.title)}</Typography>
        </Box>
      </Box>
    </Box>
  );
}

export default AnimeInfo;
