import { Box, Button, Typography, IconButton } from "@mui/material";
import { FavoriteBorder, StarRate, VisibilityOff } from "@mui/icons-material";
import {
  AnimePin,
  AnimePinCreateValues,
} from "../../app/models/entities/animePin";
import { useTranslation } from "react-i18next";
import CircleIcon from "@mui/icons-material/Circle";
import { useStore } from "../../app/stores/store";
import { toast } from "react-toastify";

interface Props {
  animePin: AnimePin;
}

export default function AnimeStripeShortDetails({ animePin }: Props) {
  const { i18n, t } = useTranslation();
  const { animeStore } = useStore();

  const getTitleByLanguage = () => {
    switch (i18n.language) {
      case "en":
        return (
          <Box>
            <Typography variant="h6">
              {animePin.anime.titleInEnglish}
            </Typography>
          </Box>
        );
      case "ua": // Assuming 'uk' is the code for Ukrainian
        return (
          <Box>
            <Typography variant="h6">
              {animePin.anime.titleInUkrainian}
            </Typography>
          </Box>
        );
      case "ru": // Assuming 'ru' is the code for Russian
        return (
          <Box>
            <Typography variant="h6">
              {animePin.anime.titleInRussian}
            </Typography>
          </Box>
        );
      default:
        return (
          <Box>
            <Typography variant="h6">
              {animePin.anime.titleInEnglish}
            </Typography>
          </Box>
        ); // Fallback to English if no match
    }
  };

  const postAddAnimeToAnotherList = async (
    pinType: string,
    selectedAnimePin: AnimePin
  ) => {
    const animePin: AnimePinCreateValues = {
      animeId: selectedAnimePin!.anime.id,
      pinType: pinType,
      grade: selectedAnimePin.grade,
      isFavorite: selectedAnimePin.isFavorite,
    };
    await animeStore.pinAnimeToUser(animePin);
  };
  const handleAddToAnotherList = async (
    pinType: string,
    selectedAnimePin: AnimePin
  ) => {
    await postAddAnimeToAnotherList(pinType, selectedAnimePin).finally(() => {
      animePin.pinType = pinType;
      toast.success(t("Anime successfully moved to another list"), {
        position: "bottom-right",
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
      });
    }); // TODO: Handle a grading anime by user, now grades doesn't works.
  };

  return (
    <Box
      display="flex"
      alignItems="center"
      justifyContent="space-between"
      p={0.5}
      border={1}
      borderRadius={1}
      mb={1}
    >
      {/* Image */}
      <Box
        component="img"
        src={animePin.anime.picture.url}
        alt={animePin.anime.titleInEnglish}
        width={40}
        height={60}
        borderRadius={1}
      />

      {/* Anime details */}
      <Box
        sx={{ display: "flex", alignItems: "center", flexDirection: "row" }}
        ml={2}
        flexGrow={1}
      >
        {animePin.anime.animeState === "Released" && (
          <CircleIcon
            sx={{
              fontSize: 18,
              marginRight: "5px",
            }}
            htmlColor="#23de05"
          />
        )}
        {getTitleByLanguage()}
        {animePin.grade && (
          <Box
            sx={{ display: "flex", flexDirection: "row", alignItems: "center" }}
          >
            <StarRate sx={{ fontSize: "1.4rem" }} />
            <Typography variant="h6">{`:${animePin.grade}`}</Typography>
          </Box>
        )}
      </Box>

      {/* Buttons */}
      <Box display="flex" gap={1}>
        <Button
          variant="outlined"
          sx={{
            backgroundColor: "black",
            color: "white",
            "&:hover": {
              color: "black",
              backgroundColor: "white",
              borderColor: "black",
            },
          }}
          onClick={() => {
            /* Add to Watched logic */
            handleAddToAnotherList("Watched", animePin);
          }}
        >
          {t("Watched")}
        </Button>
        <Button
          variant="outlined"
          sx={{
            backgroundColor: "black",
            color: "white",
            "&:hover": {
              color: "black",
              backgroundColor: "white",
              borderColor: "black",
            },
          }}
          onClick={() => {
            /* Add to Will Watch logic */
          }}
        >
          {t("Will Watch")}
        </Button>
        <IconButton
          sx={{
            backgroundColor: "black",
            color: "white",
            "&:hover": {
              color: "black",
              backgroundColor: "white",
              borderColor: "black",
            },
          }}
          onClick={() => {
            /* Add to Abandoned logic */
          }}
        >
          <VisibilityOff />
        </IconButton>
        <IconButton
          sx={{
            backgroundColor: "black",
            color: "white",
            "&:hover": {
              color: "black",
              backgroundColor: "white",
              borderColor: "black",
            },
          }}
          onClick={() => {
            /* Add to Favorites logic */
          }}
        >
          <FavoriteBorder />
        </IconButton>
      </Box>
    </Box>
  );
}
