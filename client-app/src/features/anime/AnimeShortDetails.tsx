import {
  Card,
  CardMedia,
  CardContent,
  Typography,
  Badge,
  Box,
} from "@mui/material";
import { Anime } from "../../app/models/entities/anime";
import "@fontsource/roboto/300.css"; // Light weight
import "@fontsource/roboto/400.css"; // Regular weight
import "@fontsource/roboto/500.css"; // Medium weight
import "@fontsource/roboto/700.css"; // Bold weight
import { StarRate } from "@mui/icons-material";
import { useTranslation } from "react-i18next";

interface Props {
  anime: Anime;
}

export default function AnimeShortDetails({ anime }: Props) {
  const startDate = new Date(anime.startDate);
  const { t } = useTranslation();
  return (
    <Box>
      <Badge
        badgeContent={
          <Box sx={{ display: "flex", alignItems: "center", gap: "4px" }}>
            <StarRate sx={{ fontSize: "1.5rem" }} />
            {9.5}
          </Box>
        }
        color="primary"
        sx={{
          "& .MuiBadge-badge": {
            right: 16,
            top: 32,
            backgroundColor: "rgba(0, 0, 0, 0.7)",
            color: "white",
            borderRadius: "4px", // Set to make it a rectangle
            height: "auto",
            minWidth: "auto",
            padding: "4px 8px", // Adjust padding for rectangle shape
            fontSize: "1rem",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
          },
        }}
      >
        <Card sx={{ boxShadow: "none" }} style={{ width: "250px" }}>
          <CardMedia
            component="img"
            image={anime.picture.url}
            alt={anime.titleInEnglish}
            style={{
              height: "400px",
              width: "250px",
              objectFit: "contain",
              marginTop: "5px",
            }}
          />

          <CardContent>
            <Typography variant="body2" color="text.secondary">
              {anime.titleInJapanese}
            </Typography>
            <Typography variant="h6" component="div">
              {anime.titleInEnglish}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {t(anime.type)}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {startDate.getFullYear()}
            </Typography>
          </CardContent>
        </Card>
      </Badge>
    </Box>
  );
}
