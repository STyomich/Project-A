import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { Box, Divider, Rating } from "@mui/material";
import { useParams } from "react-router-dom";
import { observer } from "mobx-react-lite";
import AnimeTitle from "./AnimeTitle";
import AnimeInfo from "./AnimeInfo";

function AnimeDetails() {
  const { animeStore } = useStore();
  const { selectedAnime, loadAnime } = animeStore;
  const { id } = useParams();

  useEffect(() => {
    loadAnime(id!);
  }, [loadAnime, id]);

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
          flexDirection: "row",
          alignItems: "left",
          backgroundColor: "white",
          padding: 2,
          borderRadius: 1,
          width: "100%",
          maxWidth: 1200,
          boxShadow: 3,
        }}
      >
        <Box>
          <img src={selectedAnime?.picture.url} style={{ height: "400px" }} />
        </Box>
        <Box style={{ marginLeft: "20px" }} sx={{ width: "100%" }}>
          <Rating name="customized-10" max={10} size="large" />
          <AnimeTitle anime={selectedAnime} />
          <Divider
            style={{ marginTop: "20px", marginBottom: "20px" }}
            variant="middle"
          />
          <AnimeInfo anime={selectedAnime!} />
        </Box>
      </Box>
    </Box>
  );
}
export default observer(AnimeDetails);
