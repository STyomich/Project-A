import { useTranslation } from "react-i18next";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { Box } from "@mui/material";

interface Props {
  animeId: string;
}

export default function AnimeDetails({ animeId }: Props) {
  const { t } = useTranslation();
  const { animeStore } = useStore();
  const { selectedAnime, loadAnime} = animeStore;

  useEffect(() => {
    loadAnime(animeId);
  }, [loadAnime, animeId]);

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "top",
        minHeight: "100vh",
        marginTop: "100px",
      }}
    ></Box>
  );
}
