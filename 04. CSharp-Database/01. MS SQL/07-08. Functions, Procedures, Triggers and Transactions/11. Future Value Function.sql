CREATE FUNCTION ufn_CalculateFutureValue( @initalSum          DECIMAL(18,4),
										  @yearlyInterestRate FLOAT,
										  @numberOfYears      DECIMAL(10,2))
RETURNS DECIMAL (18,4)
BEGIN 
	DECLARE @result DECIMAL(18,4)
	SELECT @result = @initalSum * (POWER((1 + @yearlyInterestRate),@numberOfYears))
	RETURN @result
END