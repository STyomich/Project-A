import React, { useState } from "react";
import { Button, Menu, MenuItem } from "@mui/material";

const DropdownAddToList: React.FC = () => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [menuWidth, setMenuWidth] = useState<number | undefined>(undefined); // State to store button width
  const open = Boolean(anchorEl);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
    setMenuWidth(event.currentTarget.clientWidth);
  };

  const handleClose = () => {
    setAnchorEl(null);
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
        <MenuItem onClick={handleClose}>Watching</MenuItem>
        <MenuItem onClick={handleClose}>Will Watch</MenuItem>
        <MenuItem onClick={handleClose}>Watched</MenuItem>
        <MenuItem onClick={handleClose}>Abandoned</MenuItem>
      </Menu>
    </div>
  );
};

export default DropdownAddToList;
