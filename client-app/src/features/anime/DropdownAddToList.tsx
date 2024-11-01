import React, { useState } from "react";
import { Button, Menu, MenuItem } from "@mui/material";
import {  AnimePinCreateValues } from "../../app/models/entities/animePin";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

const DropdownAddToList: React.FC = () => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [menuWidth, setMenuWidth] = useState<number | undefined>(undefined); // State to store button width
  const { animeStore} = useStore();
  const {selectedAnime} = animeStore;
  const open = Boolean(anchorEl);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
    setMenuWidth(event.currentTarget.clientWidth);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const postAnimePin = async (pinType: string, grade: number) => {
    const animePin: AnimePinCreateValues = {
      animeId: selectedAnime!.id,
      pinType: pinType,
      grade: grade,
      isFavorite: false
    };
    await animeStore.pinAnimeToUser(animePin);
  }
  const handleMenuItemClick = async (pinType: string) => {
    await postAnimePin(pinType, 1); // TODO: Handle a grading anime by user, now grades doesn't works.
    handleClose();
  };

  return (
    <div style={{ width: '100%' }}>
      <Button
        sx={{
          width: "100%",
          backgroundColor: "#0e1420",
          "&:hover": {
            backgroundColor: "black", // change background to black on hover
            color: "white", // change text color to white on hover
          },
        }}
        variant="contained"
        onClick={handleClick}
      >
        Add to list
      </Button>
      <Menu
        id="menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          "aria-labelledby": "button",
        }}
        sx={{
            '& .MuiPaper-root': {
              width: menuWidth || 'auto', // Persist the width
            },
          }}
      >
        <MenuItem onClick={()=> handleMenuItemClick("Watching")}>Watching</MenuItem>
        <MenuItem onClick={()=> handleMenuItemClick("Will Watch")}>Will Watch</MenuItem>
        <MenuItem onClick={()=> handleMenuItemClick("Watched")}>Watched</MenuItem>
        <MenuItem onClick={()=> handleMenuItemClick("Abandoned")}>Abandoned</MenuItem>
      </Menu>
    </div>
  );
};

export default observer( DropdownAddToList);
