import i18n from "../../utils/i18n";


const LanguageSwitcher = () => {
  const changeLanguage = (lng: string) => {
    i18n.changeLanguage(lng);
  };

  return (
    <div>
      <button onClick={() => changeLanguage('en')}>English</button>
      <button onClick={() => changeLanguage('ru')}>Русский</button>
      <button onClick={() => changeLanguage('ua')}>Українська</button>
    </div>
  );
};

export default LanguageSwitcher;
