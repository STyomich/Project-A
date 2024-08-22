import { useTranslation } from "react-i18next";
import { Anime } from "../../app/models/entities/anime";
import { Box, Typography } from "@mui/material";

interface Props {
  anime: Anime | undefined;
}

function AnimeTitle({ anime }: Props) {
  const { i18n } = useTranslation();

  const getTitleByLanguage = () => {
    switch (i18n.language) {
      case "en":
        return (
          <Box>
            <Typography style={{ fontWeight: "bold" }} variant="h3">
              {anime?.titleInEnglish}
            </Typography>
            <Typography>{anime?.titleInJapanese}</Typography>
            <Typography>{anime?.titleInUkrainian}</Typography>
            <Typography>{anime?.titleInRussian}</Typography>
          </Box>
        );
      case "ua": // Assuming 'uk' is the code for Ukrainian
        return (
          <Box>
            <Typography style={{ fontWeight: "bold" }} variant="h3">
              {anime?.titleInUkrainian}
            </Typography>
            <Typography>{anime?.titleInJapanese}</Typography>
            <Typography>{anime?.titleInEnglish}</Typography>
            <Typography>{anime?.titleInRussian}</Typography>
          </Box>
        );
      case "ru": // Assuming 'ru' is the code for Russian
        return (
          <Box>
            <Typography style={{ fontWeight: "bold" }} variant="h3">
              {anime?.titleInRussian}
            </Typography>
            <Typography>{anime?.titleInJapanese}</Typography>
            <Typography>{anime?.titleInUkrainian}</Typography>
            <Typography>{anime?.titleInEnglish}</Typography>
          </Box>
        );
      default:
        return (
          <Box>
            <Typography style={{ fontWeight: "bold" }} variant="h3">
              {anime?.titleInEnglish}
            </Typography>
            <Typography>{anime?.titleInJapanese}</Typography>
            <Typography>{anime?.titleInUkrainian}</Typography>
            <Typography>{anime?.titleInRussian}</Typography>
          </Box>
        ); // Fallback to English if no match
    }
  };

  return getTitleByLanguage();
}
export default AnimeTitle;
