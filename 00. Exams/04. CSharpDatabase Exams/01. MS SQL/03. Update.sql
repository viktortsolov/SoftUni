UPDATE Cigars
SET PriceForSingleCigar = 1.2 * PriceForSingleCigar
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL