import { Box, Typography } from "@mui/material";
import { useParams } from "react-router-dom";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import UsersAnimeList from "./UsersAnimeList";
import { useEffect } from "react";

export default observer(function ProfilePage() {
  const { nickname } = useParams();
  const { userStore, animeStore } = useStore();
  const { user } = userStore;
  const { usersAnimes, loadAnimeFromUserList } = animeStore;
  useEffect(() => {
    loadAnimeFromUserList(nickname!);
    console.log("Loading anime for user:", nickname);
  }, [loadAnimeFromUserList, nickname]);
  
  useEffect(() => {
    console.log("User's Animes:", usersAnimes);
  }, [usersAnimes]);
  
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
          display: "flow",
          alignItems: "left",
          backgroundColor: "white",
          padding: 2,
          borderRadius: 1,
          width: "100%",
          maxWidth: 1200,
          boxShadow: 3,
        }}
      >
        {/* User information */}
        {user && (
          <Box sx={{ display: "flex", flexDirection: "row", marginBottom:"20px" }}>
            <Box>
              <img
                src={user.avatar.url}
                style={{ marginRight: "10px" }}
                width="250"
                height="250"
                alt="Users profile image"
              />
            </Box>
            <Box>
              <Typography
                style={{ fontWeight: "bold", marginBottom: "20px" }}
                variant="h3"
              >
                {user.userNickname}
              </Typography>
              {user.userSettings.profileIsPublic ? (
                <>
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "row",
                      alignItems: "center", // align items vertically
                      justifyContent: "space-between", // align items horizontally
                      backgroundColor: "white",
                      maxWidth: 900,
                    }}
                    style={{ marginBottom: "5px" }}
                  >
                    <Box>
                      <Typography>Name:</Typography>
                    </Box>
                    <Box>
                      <Typography>{user.userName}</Typography>
                    </Box>
                  </Box>
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "row",
                      alignItems: "center", // align items vertically
                      justifyContent: "space-between", // align items horizontally
                      backgroundColor: "white",
                      maxWidth: 900,
                    }}
                    style={{ marginBottom: "5px" }}
                  >
                    <Box>
                      <Typography>Surname:</Typography>
                    </Box>
                    <Box>
                      <Typography>{user.userSurname}</Typography>
                    </Box>
                  </Box>
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "row",
                      alignItems: "center", // align items vertically
                      justifyContent: "space-between", // align items horizontally
                      backgroundColor: "white",
                      maxWidth: 900,
                    }}
                    style={{ marginBottom: "5px" }}
                  >
                    <Box>
                      <Typography>Country:</Typography>
                    </Box>
                    <Box>
                      <Typography>{user.country}</Typography>
                    </Box>
                  </Box>
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "row",
                      alignItems: "center", // align items vertically
                      justifyContent: "space-between", // align items horizontally
                      backgroundColor: "white",
                      maxWidth: 900,
                    }}
                    style={{ marginBottom: "5px" }}
                  >
                    <Box>
                      <Typography>Bio:</Typography>
                    </Box>
                    <Box>
                      <Typography>{user.bio}</Typography>
                    </Box>
                  </Box>
                </>
              ) : (
                <Typography>Profile is private</Typography>
              )}
            </Box>
          </Box>
        )}
        {/* Users anime list */}
        {user && <UsersAnimeList usersAnimes={usersAnimes} />}
      </Box>
    </Box>
  );
});
