import React, { useState } from "react";
import { Tabs, Tab, Box, Typography } from "@mui/material";
import { observer } from "mobx-react-lite";
import { AnimePin } from "../../app/models/entities/animePin";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`tabpanel-${index}`}
      aria-labelledby={`tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          {/* Change Typography to use div as the underlying component */}
          <Typography component="div">{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `tab-${index}`,
    "aria-controls": `tabpanel-${index}`,
  };
}

interface Props {
  usersAnimes: AnimePin[]; // Accept an array of Anime as a prop
}

const UsersAnimeList: React.FC<Props> = ({ usersAnimes }) => {
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  // Filter animes based on some criteria (e.g., watching, will watch, etc.)
  const watchingAnimes = usersAnimes.filter(animePin => animePin.pinType === 'Watching');
  const willWatchAnimes = usersAnimes.filter(animePin => animePin.pinType === 'Will Watch');
  const watchedAnimes = usersAnimes.filter(animePin => animePin.pinType === 'Watched');
  const abandonedAnimes = usersAnimes.filter(animePin => animePin.pinType === 'Abandoned');

  return (
    <Box sx={{ width: '100%' }}>
      <Tabs value={value} onChange={handleChange} aria-label="anime tabs">
        <Tab label="Watching" {...a11yProps(0)} />
        <Tab label="Will Watch" {...a11yProps(1)} />
        <Tab label="Watched" {...a11yProps(2)} />
        <Tab label="Abandoned" {...a11yProps(3)} />
      </Tabs>

      <TabPanel value={value} index={0}>
        {watchingAnimes.length ? (
          watchingAnimes.map(animePin => (
            <Typography key={animePin.anime.id} component="div">{animePin.anime.titleInEnglish}</Typography>
          ))
        ) : (
          <Typography component="div">No animes in Watching</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={1}>
        {willWatchAnimes.length ? (
          willWatchAnimes.map(animePin => (
            <Typography key={animePin.anime.id} component="div">{animePin.anime.titleInEnglish}</Typography>
          ))
        ) : (
          <Typography component="div">No animes in Will Watch</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={2}>
        {watchedAnimes.length ? (
          watchedAnimes.map(animePin => (
            <Typography key={animePin.anime.id} component="div">{animePin.anime.titleInEnglish}</Typography>
          ))
        ) : (
          <Typography component="div">No animes in Watched</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={3}>
        {abandonedAnimes.length ? (
          abandonedAnimes.map(animePin => (
            <Typography key={animePin.anime.id} component="div">{animePin.anime.titleInEnglish}</Typography>
          ))
        ) : (
          <Typography component="div">No animes in Abandoned</Typography>
        )}
      </TabPanel>
    </Box>
  );
};

export default observer(UsersAnimeList);
