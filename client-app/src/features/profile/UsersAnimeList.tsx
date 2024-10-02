import React, { useState } from 'react';
import { Tabs, Tab, Box, Typography } from '@mui/material';

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
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `tab-${index}`,
    'aria-controls': `tabpanel-${index}`,
  };
}

const UsersAnimeList: React.FC = () => {
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Box sx={{ width: '100%' }}>
      <Tabs value={value} onChange={handleChange} aria-label="anime tabs">
        <Tab label="Watching" {...a11yProps(0)} />
        <Tab label="Will Watch" {...a11yProps(1)} />
        <Tab label="Watched" {...a11yProps(2)} />
        <Tab label="Abandoned" {...a11yProps(3)} />
      </Tabs>

      <TabPanel value={value} index={0}>
        Content for Watching
      </TabPanel>
      <TabPanel value={value} index={1}>
        Content for Will Watch
      </TabPanel>
      <TabPanel value={value} index={2}>
        Content for Watched
      </TabPanel>
      <TabPanel value={value} index={3}>
        Content for Abandoned
      </TabPanel>
    </Box>
  );
};

export default UsersAnimeList;
