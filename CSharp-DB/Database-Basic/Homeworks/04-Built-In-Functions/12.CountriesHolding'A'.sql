SELECT CountryName,IsoCode
	FROM Countries
  WHERE LEN(CountryName) - LEN(Replace(CountryName,'A','')) >= 3
 ORDER BY IsoCode