import React, { useState } from "react";
import { Tabs, Tab, Box, Typography } from "@mui/material";
import { observer } from "mobx-react-lite";
import { AnimePin } from "../../app/models/entities/animePin";
import AnimeStripeShortDetails from "./AnimeStripeShortDetails";
import { useTranslation } from "react-i18next";

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
  usersAnimes: AnimePin[];
}

const UsersAnimeList: React.FC<Props> = ({ usersAnimes }) => {
  const [value, setValue] = useState(0);
  const { t } = useTranslation();

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const watchingAnimes = usersAnimes.filter(
    (animePin) => animePin.pinType === "Watching"
  );
  const willWatchAnimes = usersAnimes.filter(
    (animePin) => animePin.pinType === "Will Watch"
  );
  const watchedAnimes = usersAnimes.filter(
    (animePin) => animePin.pinType === "Watched"
  );
  const abandonedAnimes = usersAnimes.filter(
    (animePin) => animePin.pinType === "Abandoned"
  );

  return (
    <Box sx={{ width: "100%" }}>
      <Tabs
        value={value}
        onChange={handleChange}
        aria-label="anime tabs"
        sx={{
          ".MuiTabs-flexContainer": {
            backgroundColor: "#0e1420",
          },
          ".MuiTabs-indicator": {
            backgroundColor: "white", // Change indicator color to white
          },
        }}
      >
        <Tab
          label={t("Watching")}
          {...a11yProps(0)}
          sx={{
            color: "white",
            "&.Mui-selected": {
              color: "white", // Selected text color stays white
              backgroundColor: "black", // Selected tab background remains black
            },
            "&:hover": {
              color: "black",
              backgroundColor: "white",
            },
          }}
        />
        <Tab
          label={t("Will Watch")}
          {...a11yProps(1)}
          sx={{
            color: "white",
            "&.Mui-selected": {
              color: "white",
              backgroundColor: "black",
            },
            "&:hover": {
              color: "black",
              backgroundColor: "white",
            },
          }}
        />
        <Tab
          label={t("Watched")}
          {...a11yProps(2)}
          sx={{
            color: "white",
            "&.Mui-selected": {
              color: "white",
              backgroundColor: "black",
            },
            "&:hover": {
              color: "black",
              backgroundColor: "white",
            },
          }}
        />
        <Tab
          label={t("Abandoned")}
          {...a11yProps(3)}
          sx={{
            color: "white",
            "&.Mui-selected": {
              color: "white",
              backgroundColor: "black",
            },
            "&:hover": {
              color: "black",
              backgroundColor: "white",
            },
          }}
        />
      </Tabs>

      <TabPanel value={value} index={0}>
        {watchingAnimes.length ? (
          watchingAnimes.map((animePin) => (
            <AnimeStripeShortDetails
              key={animePin.animeId}
              animePin={animePin}
            />
          ))
        ) : (
          <Typography component="div">No animes in Watching</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={1}>
        {willWatchAnimes.length ? (
          willWatchAnimes.map((animePin) => (
            <AnimeStripeShortDetails
              key={animePin.animeId}
              animePin={animePin}
            />
          ))
        ) : (
          <Typography component="div">No animes in Will Watch</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={2}>
        {watchedAnimes.length ? (
          watchedAnimes.map((animePin) => (
            <AnimeStripeShortDetails
              key={animePin.animeId}
              animePin={animePin}
            />
          ))
        ) : (
          <Typography component="div">No animes in Watched</Typography>
        )}
      </TabPanel>
      <TabPanel value={value} index={3}>
        {abandonedAnimes.length ? (
          abandonedAnimes.map((animePin) => (
            <AnimeStripeShortDetails
              key={animePin.animeId}
              animePin={animePin}
            />
          ))
        ) : (
          <Typography component="div">No animes in Abandoned</Typography>
        )}
      </TabPanel>
    </Box>
  );
};

export default observer(UsersAnimeList);
