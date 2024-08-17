import { Grid } from "@mui/material";
import { Anime } from "../../app/models/entities/anime";
import AnimeShortDetails from "./AnimeShortDetails";

interface Props {
  animeList: Anime[];
}

export default function Dashboard({ animeList }: Props) {
  return (
    <Grid style={{marginTop:"50px"}} container spacing={2}>
      {animeList.map((anime) => (
        <Grid item 
          xs={12} 
          sm={6} 
          md={4} 
          lg={3} 
          xl={2} 
          key={anime.id}
          sx={{ marginRight: 4 }}>
          <AnimeShortDetails anime={anime} />
        </Grid>
      ))}
    </Grid>
  );
}
