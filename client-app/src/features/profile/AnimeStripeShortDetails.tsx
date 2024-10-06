import { Box, Button, Typography, IconButton } from "@mui/material";
import {
  FavoriteBorder,
  VisibilityOff,
} from "@mui/icons-material";
import { AnimePin } from "../../app/models/entities/animePin";

interface Props{
    animePin: AnimePin
}

export default function AnimeStripeShortDetails({ animePin }: Props) {
  return (
    <Box
      display="flex"
      alignItems="center"
      justifyContent="space-between"
      p={2}
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
      <Box ml={2} flexGrow={1}>
        <Typography variant="h6">{animePin.anime.titleInEnglish}</Typography>
        <Typography variant="subtitle2">{`Grade: ${
          animePin.grade ?? "N/A"
        }`}</Typography>
      </Box>

      {/* Buttons */}
      <Box display="flex" gap={1}>
        <Button
          variant="outlined"
          sx={{backgroundColor:"black", color:"white"}}
          onClick={() => {
            /* Add to Watched logic */
          }}
        >
          Watched
        </Button>
        <Button
          variant="outlined"
          sx={{backgroundColor:"black", color:"white"}}
          onClick={() => {
            /* Add to Will Watch logic */
          }}
        >
          Will Watch
        </Button>
        <IconButton
        sx={{backgroundColor:"black", color:"white"}}
          onClick={() => {
            /* Add to Abandoned logic */
          }}
        >
          <VisibilityOff />
        </IconButton>
        <IconButton
        sx={{backgroundColor:"black", color:"white"}}
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
