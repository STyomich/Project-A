import React from 'react';
import { MenuItem, Select, FormControl, InputLabel } from '@mui/material';
import { useTranslation } from 'react-i18next';



const LanguageSelector = () => {
  const { i18n } = useTranslation();
  const currentLanguage = i18n.language;

  const handleChange = (event) => {
    const newLanguage = event.target.value;
    i18n.changeLanguage(newLanguage);
  };

  return (
    <FormControl style={{width:'135px'}}>
      <Select
        value={currentLanguage}
        onChange={handleChange}
        displayEmpty
        variant="outlined"
        style ={{fontWeight:"bold"}}
        sx={{
          color: "white",
          '.MuiOutlinedInput-notchedOutline': {
            borderColor: '#0e1420',
          },
          '&.Mui-focused .MuiOutlinedInput-notchedOutline': {
            borderColor: 'white',
          },
          '&:hover .MuiOutlinedInput-notchedOutline': {
            borderColor: '#0e1420',
          },
          '.MuiSvgIcon-root ': {
            fill: "white",
          }
        }}
      >
        <MenuItem value="en">English</MenuItem>
        <MenuItem value="ru">Русский</MenuItem>
        <MenuItem value="ua">Українська</MenuItem>
      </Select>
    </FormControl>
  );
};

export default LanguageSelector;
